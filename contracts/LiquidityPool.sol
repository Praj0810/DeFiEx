// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./LpToken.sol";
import "./SpaceCoin.sol";
import "../ERC20 /Ownable.sol";
import "../ERC20 /Math.sol";

contract LiquidityPool is Ownable {
    /*************************************************************************************
    *@notice Eimt when a user add liquidity to the pool
    *@param _account address of the liquidity provider
    */
    event Addliquidity(address indexed _account);
    /***********************************************************************
     *@notice Eimt when a liquidity provider remove liquidity from the pool
     *@param _account address of the liquidity provider
     */
    event Removeliquidity(address indexed _account);
    /************************************************************************
     *@notice Eimt when some trade either ETH to Neo Token or Neo Token to ETH
     *@param _account address of the trader
     *@param _ethTraded amount of ETH in trade
     *@param _neoTraded amount of Neo Token in trade
     */
    event TokenTrade(address indexed _account, uint256 _tradeEther, uint256 _tradeSpCoin);
    
     //instance of LPToken contract 
    LpToken public lpToken;
     //instance of spaceCoin Token contract
    SpaceCoin public spaceCoin;
    //Ether Reserve of the liquidity pool
    uint256 etherReserve;
    //SpaceCoin Token Reserve of liquidity pool
    uint256 SpCoinReserve;

     /****************************************************************************************
     *@notice set the LPToken contract address to liquidity pool
     *
     *@dev developer needs to pass address of LPToken contract
     *
     *@param _lptoken address of the LPToken contract
     *
     *Requirements
     *
     * only owner able to call and set the address of  LPToken contract
     * address should be set only once after deploying contract
     */
    function setLPTokenAddress(LpToken _lpToken) external onlyOwner{
        require(address(lpToken)== address(0),"set only once");
        lpToken = _lpToken;
    }
     /****************************************************************************************
     *@notice to get the ETH and SpaceCoin Reserve of Liquidity Pool
     */
    function getReserves() external view returns(uint256, uint256){
        return(etherReserve, SpCoinReserve);
    }

     /********************************************************************************
     *@notice this function set the SpaceCoin token contract address to liquidity pool
     *
     *@dev developer needs to pass address of SpaceCoin contract
     *
     *@param _spaceCoin address of the SpaceCoin contract
     *
     *Requirements
     *
     * only owner able to call and set the address of SpaceCoin contract
     * address should be set only once after deploying contract
     */
    function setSpCoinAddress(SpaceCoin _spaceCoin) external onlyOwner{
        require(address(spaceCoin)== address(0),"Set only once");
        spaceCoin = _spaceCoin;
    }

    /********************************************************************************
     *@notice to swap your ETH to NeoToken or NeoToken to ETH
     *
     *@param _account address of person who want ot swap token
     *@param _spcAmount amount of spaceCoin token user want to swap
     *
     */
    function swap(address _account, uint256 _spcAmount) external payable{
        uint256 constantProduct = etherReserve * SpCoinReserve;
        uint256 amountToTransfer;

        if(msg.value == 0){
            uint256 currentSpacecoinBal = spaceCoin.balanceOf(address(this));
            uint256 balanceAdded = SpCoinReserve + _spcAmount;

            require(balanceAdded == currentSpacecoinBal, "No transfer happen");
            
            uint256 x = constantProduct /(currentSpacecoinBal);
            amountToTransfer = etherReserve - x;
            (bool success ,) = _account.call{value: amountToTransfer}("");
            require(success);
        }else{
            uint256  y = constantProduct/ (etherReserve + msg.value);
            amountToTransfer = SpCoinReserve - y;
            spaceCoin.transfer(_account,amountToTransfer);
        }
        emit TokenTrade(_account, msg.value, _spcAmount);
        _update();
    }

    /*********************************************************************************
     *@notice This function deposit liquidity from the liquiditypool
     *
     *@param _spcAmount amount od spaceCoin token provided by msg.sender to liquidity Pool 
     *@param _account address of the liquidity provider 
     *Requirements
     *
     *msg.sender must have SpaceCoin Token for liquidtity pool.
     *msg.sender must have Ether for liquidtity pool.
     */
    function depositfunds(uint256 _spcAmount, address _account) external payable {
        uint256 liquidity;
        uint256 totalSupply = lpToken.balanceOf(_account);
        uint256 EthAmount = msg.value;
        
        if(totalSupply > 0){
            liquidity = Math.min((EthAmount * totalSupply)/ etherReserve, (_spcAmount * totalSupply)/ SpCoinReserve);
        }else{
            liquidity = Math.sqrt(EthAmount * _spcAmount);
        }
        lpToken.mint(_account, liquidity);
        emit Addliquidity(_account);
        _update();

    }

    /**********************************************************************************
     *@notice This function withdraw the liquidity from the liquiditypool
     *
     *@param _account address of liquidity provider
     *
     *msg.sender must have LPToken
     *
     */
    function withdrawfunds(address _account) external  {
        uint liquidity = lpToken.balanceOf(_account);
        require(liquidity != 0, "NO tokens Available");

        uint256 totalSupply = lpToken.totalSupply();

        uint EthAmount = (etherReserve * liquidity)/ totalSupply;
        uint spcAmount = (SpCoinReserve * liquidity)/ totalSupply;

        lpToken.burn(_account, liquidity);
        (bool ethTransferSuccess,)= _account.call{value :EthAmount}("");
        bool SpaceCoinTransferSuccess = spaceCoin.transfer(_account, spcAmount);

        require(ethTransferSuccess && SpaceCoinTransferSuccess, "Transfer fail");
        emit Removeliquidity(_account);
        _update();
    }

    /***********************************************************************************
    *@notice to update the ethReserve and neoReserve
    */
    function _update() private{
        etherReserve = address(this).balance;
        SpCoinReserve = spaceCoin.balanceOf(address(this));
    }
}

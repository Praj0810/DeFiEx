// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./SpaceCoin.sol";
import "./LiquidityPool.sol";
import "../ERC20 /Ownable.sol";

contract DeFiRouter is Ownable{
    //instance of spacecoin token contract
    SpaceCoin public spaceCoin;
    //instance of liquidity Pool Contract
    LiquidityPool public liquidityPool;
    
    /*********************************************************************************
     *@notice set the Liquidity Pool contract address to Router
     *
     *@dev developer needs to pass address of Liquidity Pool  contract
     *
     *@param _liquidityPool address of the Liquidity Pool contract
     *
     *Requirements
     * only owner able to call and set the address of Liquidity Pool contract
     * address should be created only once after deploying contract
     */    
    function setLiquidityPoolAddress(LiquidityPool _liquidityPool) external onlyOwner{
        require(address(liquidityPool)== address(0), "written only once");
        liquidityPool = _liquidityPool;
    }

    /*********************************************************************************
     *@notice set the SpaceCoin token contract address to Router
     *
     *@dev developer needs to pass address of SpaceCoin  contract
     *
     *@param _spaceCoin address of the SpaceCoin contract
     *
     *Requirements
     *
     * only owner able to call and set the address of SpaceCoin contract
     * address should be created only once after deploying contract
     */
    function setSpaceCoinAddress(SpaceCoin _spaceCoin) external onlyOwner{
        require(address(spaceCoin)== address(0),"written only once");
        spaceCoin = _spaceCoin;
    }

    /*********************************************************************************
     *@notice This function add Liquidity to the Liquidity Pool
     *
     *@param _spcAmount  aamount of SpaceCoin added to the liquidity Pool
     *
     *msg.sender should have Ether for Liquidity Pool
     *msg.sender should have SpaceCoin for Liquidity Pool
     */
    function addLiquidity(uint256 _spcAmount) external payable{
        require(spaceCoin.balanceOf(msg.sender)> 0,"Token not available");

        bool success = spaceCoin.increaseDRoutAllowance(msg.sender, address(this), _spcAmount);
        require(success);

        spaceCoin.transferFrom(msg.sender, address(liquidityPool), _spcAmount);
        liquidityPool.depositfunds{value : msg.value}(_spcAmount,msg.sender);
    }
    
    /*********************************************************************************
     *@notice This function pulls the Liquidity 
     *
     * msg.sender must be the Liquidity provider.
     **/
    function removeLiquidity() external{
        liquidityPool.withdrawfunds(msg.sender);
    }

    /**********************************************************************************
     *@notice This function swap the Ether with SpaceCoin Token or Vice a versa
     *
     *@dev developer needs to pass SpaceCoin for SpaceCoin to Ether Swap 
     *     or pass Ether for Ether to Spacecoin Swap
     *
     *@param _spcAmount amount of spaceCoin Token to swap
     *
     **/
    function tokenSwap(uint256 _spcAmount) external payable{
        bool success = spaceCoin.increaseDRoutAllowance(msg.sender, address(this), _spcAmount);
        require(success);

        spaceCoin.transferFrom(msg.sender, address(liquidityPool), _spcAmount);
        liquidityPool.swap{value:msg.value}(msg.sender, _spcAmount);
    }
    
    

}
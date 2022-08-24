// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "../ERC20 /ERC20.sol";

contract SpaceCoin is ERC20{
    //owner address of spacecoin contract
    address public tokenOwner;

    //owner address of DeFiRouter contract
    address public DefiRouter;

    /** 
    *@dev provide the name and the symbol of the token
    */
    constructor() ERC20 ("SpaceCoin","SPC"){
        tokenOwner = msg.sender;
        _mint(msg.sender, 1000);
    }

    //to check whether msg.sender is owner of SpaceCoin contract or not.
    modifier onlyOwner(){
        require(msg.sender == tokenOwner, " User is not owner of the SpaceCoin token");
        _;
    } 

    //to check whether msg.sender is DefiRouter or not.
    modifier onlyDefiRouter(){
        require(msg.sender == DefiRouter, "Not Defi Router");
        _;
    }
    
    /***
    * @notice This function set the address of DefiRouter.
    * 
    * @dev developer needs to pass the address DefiRouter.
    *
    * @param _DefiRouter address of the  DefiRouter
    *
    * only owner of this contract will be able top call and set the address of the router
    * address is set only once after Deploying the contract
    **/
    function setRouter(address _DefiRouter) external onlyOwner{
        require(DefiRouter == address(0) , "written only once");
        DefiRouter = _DefiRouter;
    }

    /***
    * @notice This function set the allowance to Defirouter from msg.sender.
    * 
    * @dev developer needs to pass the address of DefiRouter.
    *
    * @param _tokenOwner address of the msg.sender
    * @param _spender address of the Defirouter
    * @param _amount amount that msg.sender need to allow to spend to the Defirouter.
    * only DefiRouter contract will be able to call
    * @return bool for Allowance success 
    **/
    function increaseDRoutAllowance(address _tokenOwner, address _spender, uint256 _amount) public onlyDefiRouter returns(bool){
        _approve(_tokenOwner, _spender, allowance(msg.sender, address(this))+ _amount);
        return true;
    }
    
}

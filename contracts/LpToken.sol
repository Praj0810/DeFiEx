// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "../ERC20 /ERC20.sol";
import  "../ERC20 /Ownable.sol";

contract LpToken is ERC20, Ownable {
    //address of Liquidity Pool
    address lipoolAddress;
    /**
    *@dev to provide the name and the symbol of the Token
    */
    constructor() ERC20("Liquidity Pool Token", "LPT"){
    }

    /***
    * @notice to transfer the Ownership of LPtoken contract to Liquidity Pool
    * 
    *@dev developer needs to pass the address of Liquidity Pool.
    *
    * @param _lipoolAddress address of the  Liquidty Pool
    * 
    * Requirements
    * only owner of liquidity Pool contract will be able to call and transfer the ownership to Liquidity Pool
    **/
    function setLipoolAddress(address _lipoolAddress) external onlyOwner{
        require(lipoolAddress == address(0), "Written Only once");
        lipoolAddress = _lipoolAddress;
        transferOwnership(_lipoolAddress);

    }

    /***
    * @notice to mint the LPtoken for Liquidity Provider when he wants to pull liquidity
    * 
    * @param account address of Liquidity Provider
    *
    * @param amount of LPtoken to be mint from Liquidty Pool
    * 
    * Requirements
    * only owner of liquidity Pool contract will be able to call and mint the LPToken for Liquidity Provider
    **/
    function mint(address account, uint256 amount) external onlyOwner{
        _mint(account, amount);

    }

    /***
    * @notice to burn the LPtoken for Liquidity Provider when he wants to pull liquidity
    * 
    * @param account address of Liquidity Provider
    *
    * @param amount of LPtoken to be burn from Liquidty Pool
    * 
    * Requirements
    * only owner of liquidity Pool contract will be able to call and burn the LPToken for Liquidity Provider
    **/
    function burn(address account, uint256 amount) external onlyOwner{
        _burn(account, amount);
    }       
}




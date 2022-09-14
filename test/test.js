const SpaceCoin = artifacts.require("SpaceCoin");
const DeFiRouter = artifacts.require("DeFiRouter");
const LpToken = artifacts.require("LpToken");
const LiquidityPool = artifacts.require("LiquidityPool");


contract ("DeFiExchange App" , accounts => {
    let _SpaceCoin, _LpToken , _LiquidityPool , _DeFiRouter ;
    before(async ()=>  {
        _SpaceCoin = await SpaceCoin.deployed();
        console.log("SpaceCoin" , _SpaceCoin.address);
        _LpToken = await LpToken.deployed();
        console.log("LpToken", _LpToken.address);
        _LiquidityPool = await LiquidityPool.deployed();
        console.log("LiquidityPool" , _LiquidityPool.address);
        _DeFiRouter = await DeFiRouter.deployed();
        console.log("DeFiRouter" , _DeFiRouter.address);
    });

    it("All contract should get deployed properly",async() =>{
        assert(_DeFiRouter.address !== "");
        assert(_LpToken.address !== "");
        assert(_SpaceCoin.address !== "");
        assert(_LiquidityPool.address !== "");
    });

    it("1000 SpaceCoin token mint to Account[0]" , async() =>{
        let _balanceTokenOfOwner = await _SpaceCoin.balanceOf(accounts[0],{from: accounts[0]});
        assert(_balanceTokenOfOwner == 1000); 
    });

    it("LpToken ownership transfer to liquidity Pool by Account[0] " , async() =>{
        await _LpToken.setLipoolAddress(_LiquidityPool.address);
        let LpTokenNewOwner = await _LpToken.owner();
        assert(LpTokenNewOwner ==  _LiquidityPool.address);
    });

    it("set the LpToken and SpaceCoin token COntract address in the LiquidityPool by the Account[0]" , async() =>{
        await _LiquidityPool.setLPTokenAddress(_LpToken.address, {from:accounts[0]});
        await _LiquidityPool.setSpCoinAddress(_SpaceCoin.address, {from:accounts[0]});
        let LpTokenAddress = await _LiquidityPool.lpToken();
        let SpaceCoinTokenAddress = await _LiquidityPool.spaceCoin();
        assert(LpTokenAddress == _LpToken.address);
        assert(SpaceCoinTokenAddress == _SpaceCoin.address);
    });

    it("set the LiquidityPool and SpaceCoin Token contract address in the app by account[0] ", async() =>{
        await _DeFiRouter.setLiquidityPoolAddress(_LiquidityPool.address, {from : accounts[0]});
        await _DeFiRouter.setSpaceCoinAddress(_SpaceCoin.address, {from:accounts[0]});
        let LiquidityPoolAddress = await _DeFiRouter.liquidityPool();
        let SpaceCoinTokenAddress = await _DeFiRouter.spaceCoin();
        assert(LiquidityPoolAddress == _LiquidityPool.address);
        assert(SpaceCoinTokenAddress == _SpaceCoin.address);
    });

    it("Set the Router address in SpaceCoin Token by Account[0]" ,async() =>{
        await _SpaceCoin.setRouter(_DeFiRouter.address, {from:accounts[0]});
        let DeFiRouterAddress  = await _SpaceCoin.DeFiRouter();
        assert(DeFiRouterAddress == _DeFiRouter.address);
    });

    it("SpCoinReserve and etherReserve should be 0 in liquidity Pool", async() => {
        let reserve = await _LiquidityPool.getReserves();
        assert(reserve[0] == 0);
        assert(reserve[1] == 0);
    });

    it("Adding Liquidity to the Liquidity Pool by Liquidity Provider", async() =>{
        await _DeFiRouter.addLiquidity(300, {value : web3.utils.toWei("3", "ether"),from :accounts[0]});
        let reserve = await _LiquidityPool.getReserves();
        assert(reserve[0] == web3.utils.toWei("3", "ether"));
        assert(reserve[1] == 300);
    });

    it("Balance of SpaceCoin token after swapping with Ether in Account[1]", async() =>{
        let balanceToken = await _SpaceCoin.balanceOf(accounts[1], {from:accounts[1]});
        assert(balanceToken == 0);
        await _DeFiRouter.tokenSwap(0, {value:web3.utils.toWei("1", "ether"), from: accounts[1]});
        balanceToken = await _SpaceCoin.balanceOf(accounts[1], {from:accounts[1]});
        assert(balanceToken != 0);
    });

    it("Balance of Reserve in Liquidity Pool change", async() =>{
        let reserve = await _LiquidityPool.getReserves();
        assert(reserve[0] >= web3.utils.toWei("3", "ether"));
        assert(reserve[1] <= 300);
    });

});

    
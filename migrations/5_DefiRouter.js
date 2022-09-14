const DeFiRouter = artifacts.require("DeFiRouter");

module.exports = function (deployer) {
  deployer.deploy(DeFiRouter);
};
const LpToken = artifacts.require("LpToken");

module.exports = function (deployer) {
  deployer.deploy(LpToken);
};
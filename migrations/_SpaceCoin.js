const SpaceCoin = artifacts.require("SpaceCoin");

module.exports = function (deployer) {
  deployer.deploy(SpaceCoin,"SpaceCoin", "SPC");
};
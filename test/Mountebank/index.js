const mb = require("mountebank");
const ecommerceImposter = require("./imposter/ecommerceimposter");

const mbServerInstance = mb.create({
  port: 4001,
  pidfile: "./mb.pid",
  logfile: "./mg.log",
  protofile: "./protofile.json",
  ipWhitelist: ["*"]
});

mbServerInstance.then(function() {
  ecommerceImposter.addStubs();
});

const PROXY_CONFIG = [
  {
    context: [
      "/api/**"
    ],
    target: "http://localhost:7008",
    secure: false
  }
]

module.exports = PROXY_CONFIG;

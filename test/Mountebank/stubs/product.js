const productStubs = [
  {
    predicates: [
      {
        equals: {
          method: "GET",
          path: "/products"
        }
      }
    ],
    responses: [
      {
        is: {
          statusCode: 200,
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            success: true,
            data: [
              {
                id: "8F11AD71-D7E7-45EF-AF9E-D54EF0675C77",
                name: "Macbook Pro",
                price: 10
              }
            ]
          })
        }
      }
    ]
  },
  {
    predicates: [
      {
        equals: {
          method: "GET",
          path: "/products/8F11AD71-D7E7-45EF-AF9E-D54EF0675C77"
        }
      }
    ],
    responses: [
      {
        is: {
          statusCode: 200,
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            success: true,
            data: {
              id: "8F11AD71-D7E7-45EF-AF9E-D54EF0675C77",
              name: "Macbook Pro",
              price: 10
            }
          })
        }
      }
    ]
  },
  {
    predicates: [
      {
        equals: {
          method: "GET",
          path: "/products/0B68BD71-74B7-45F0-9382-916FC5CB52D8"
        }
      }
    ],
    responses: [
      {
        is: {
          statusCode: 200,
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            success: true,
            data: {
              id: "0B68BD71-74B7-45F0-9382-916FC5CB52D8",
              name: "Macbook Pro",
              price: 10
            }
          })
        }
      }
    ]
  }
];

module.exports = productStubs;

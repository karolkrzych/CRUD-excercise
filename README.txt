GET:              http://localhost:5000/api/products  -   list of products in database,
GET(specific):    http://localhost:5000/api/products/id   -   specific product 
POST:             http://localhost:5000/api/products    -   add product to database

    example:
    {
        "Name": "Product",
        "Price": 100
    }

PUT:              http://localhost:5000/api/products/id    -    edit specific product

    example:
    {
        "Id": "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
        "Name": "Product",
        "Price": 50
    }

DELETE:           http://localhost:5000/api/products/id    -    delete specific product

To use POST method name and price is required. 
To use PUT method name, price and ID is required.

Verification done in Postman.
# PriceChecker

__NONOTES4UJUSME__

But seriously, thank you for taking a look.

There is a LOT more to do to make this library meaningful, including:
- Android library of the same
- Looking at implementing a free ut creator
- Storing/Distributing/Loading a basic config with LitDb/NoSQL
- Connecting with LeadTools to solve scan of barcode; trial runs out on 3/14

And then later is a proper test of the VGC API, all links and notes on how to format a search string.

Start with the provided RapiAPI Playground tool (link below), but cannot alter the input there :(

Must retest in postman with my key before investing more dev time on VGC/RAPI.

JSON Input
~~~
TODO
~~~

JSON Output Schema
~~~
{
  "properties": {
    "statusCode": {
      "type": "number",
      "format": "double",
      "description": "HTTP status code",
      "minimum": -1.7976931348623157e+308,
      "maximum": 1.7976931348623157e+308
    },
    "messageCode": {
      "type": "string",
      "description": "Status message code"
    },
    "data": {
      "description": "Response data"
    }
  },
  "required": [
    "statusCode",
    "messageCode",
    "data"
  ],
  "type": "object",
  "additionalProperties": false
}
~~~

Ref: 
https://rapidapi.com/apidock-apidock-default/api/pricecharting-api/playground/

Styling Ref:
https://www.markdownguide.org/basic-syntax/

Ref of Styling: https://www.youtube.com/watch?v=bAxZJ5NVr3Q

&copy; 2026 RFR Consulting Inc, Ltd


# Barbecue API Usage

## `Barbecue`

### Create a Barbecue

***`POST Verb`***
### Request
```json
{
  "beginDate": "12/01/2024 13:00:00 -3:00",
  "endDate": "12/01/2024 16:30:00 -3:00",
  "description": "Churras da Trinca e niver do Yuri Melo rs",
  "additionalObservations": [
    "Cheguem cedo pra ajudar",
    "Os vegetarianos estão todos convidados rs",
    "Estudante não paga meia kkkk",
    "Bah, eu nunca tomei chimarrão, então levem um pra mim."
  ]
}
```
### Response
***`200 OK`***
```json
bbb0b41d-ef32-4c20-a7e3-57b2cf29d24b
```
---

### List a Barbecue

***`GET Verb`***

### Request
```json
bbb0b41d-ef32-4c20-a7e3-57b2cf29d24b
```
### Response
***`200 OK`***
```json
{
  "identifier": "bbb0b41d-ef32-4c20-a7e3-57b2cf29d24b",
  "description": "Churras da Trinca e niver do Yuri Melo rs",
  "beginDateTime": "12/01/2024 13:00:00",
  "endDateTime": "12/01/2024 16:30:00",
  "additionalRemarks": [
    "Cheguem cedo pra ajudar",
    "Os vegetarianos estão todos convidados rs",
    "Estudante não paga meia kkkk",
    "Bah, eu nunca tomei chimarrão, então levem um pra mim."
  ],
  "participants": [
    "4465e282-7af2-4b87-bbc1-4ac5201d7722"
  ]
}
```
---

## `Participant`
> Add a participant to existing Barbecue

***`POST Verb`***
### Request
```json
{
  "name": "Yuri Melo",
  "username": "@yuridsm",
  "suggestionContribution": 100.0,
  "bringDrink": true,
  "barbecueIdentifier": "bbb0b41d-ef32-4c20-a7e3-57b2cf29d24b",
  "items": [
    "Água com gás",
    "Água sem gás"
  ]
}
```
### Response
***`200 OK`***
```json
{
  "participantIdentifier": "4465e282-7af2-4b87-bbc1-4ac5201d7722"
}
```
---

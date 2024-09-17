# Robot Manager API
### Creating/Edit Naos, Issues, Notes, Clinic Visits, and Games


<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/CreateEdit/nao</b></code> <code>(Create/Edit Nao)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | Nao       |  required | object (JSON)   | The Nao object to create or edit                                      |

##### Example Value

<details>
 <summary>Click to expand</summary>

> ```json
> {
>   "id": 0,
>   "name": "string",
>   "headID": "string",
>   "bodyID": "string",
>   "warrantyExtension": 0,
>   "purchased": "2024-09-17T11:02:12.739Z",
>   "issues": [
>     {
>       "id": 0,
>       "nao": 0,
>       "title": "string",
>       "description": "string",
>       "replicated": true,
>       "solved": true,
>       "date": "2024-09-17T11:02:12.739Z",
>       "replicatedDate": "2024-09-17T11:02:12.739Z",
>       "solvedDate": "2024-09-17T11:02:12.739Z",
>       "solvedReport": "string"
>     }
>   ],
>   "notes": [
>     {
>       "id": 0,
>       "nao": 0,
>       "title": "string",
>       "description": "string",
>       "date": "2024-09-17T11:02:12.739Z"
>     }
>   ],
>   "clinicVisits": [
>     {
>       "id": 0,
>       "nao": 0,
>       "date": "2024-09-17T11:02:12.739Z",
>       "issues": [
>         {
>           "id": 0,
>           "nao": 0,
>           "title": "string",
>           "description": "string",
>           "replicated": true,
>           "solved": true,
>           "date": "2024-09-17T11:02:12.739Z",
>           "replicatedDate": "2024-09-17T11:02:12.739Z",
>           "solvedDate": "2024-09-17T11:02:12.739Z",
>           "solvedReport": "string"
>         }
>       ],
>       "isBack": true,
>       "backReport": "string"
>     }
>   ],
>   "status": 0
> }
> ```

</details>

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/CreateEdit/issue</b></code> <code>(Create/Edit Issue)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | Issue     |  required | object (JSON)   | The Issue object to create or edit                                    |

##### Example Value

<details>
 <summary>Click to expand</summary>

> ```json
>{
>  "id": 0,
>  "nao": 0,
>  "title": "string",
>  "description": "string",
>  "replicated": true,
>  "solved": true,
>  "date": "2024-09-17T11:09:10.799Z",
>  "replicatedDate": "2024-09-17T11:09:10.799Z",
>  "solvedDate": "2024-09-17T11:09:10.799Z",
>  "solvedReport": "string"
>}
> ```

</details>

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/CreateEdit/note</b></code> <code>(Create/Edit Note)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | Note      |  required | object (JSON)   | The Note object to create or edit                                     |

##### Example Value

<details>
 <summary>Click to expand</summary>

> ```json
> {
>  "id": 0,
>  "nao": 0,
>  "title": "string",
>  "description": "string",
>  "date": "2024-09-17T11:14:12.000Z"
> }
> ```

</details>

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/CreateEdit/clinicVisit</b></code> <code>(Create/Edit Clinic Visit)</code></summary>

##### Parameters

> | name          |  type     | data type               | description                                                           |
> |---------------|-----------|-------------------------|-----------------------------------------------------------------------|
> | ClinicVisit   |  required | object (JSON)   | The Clinic Visit object to create or edit                             |

##### Example Value

<details>
 <summary>Click to expand</summary>

> ```json
> {
>  "id": 0,
>  "nao": 0,
>  "date": "2024-09-17T11:14:36.982Z",
>  "issues": [
>    {
>      "id": 0,
>      "nao": 0,
>      "title": "string",
>      "description": "string",
>      "replicated": true,
>      "solved": true,
>      "date": "2024-09-17T11:14:36.982Z",
>      "replicatedDate": "2024-09-17T11:14:36.982Z",
>      "solvedDate": "2024-09-17T11:14:36.982Z",
>      "solvedReport": "string"
>    }
>  ],
>  "isBack": true,
>  "backReport": "string"
> }
> ```

</details>

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/CreateEdit/game</b></code> <code>(Create/Edit Game)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | Game      |  required | object (JSON)   | The Game object to create or edit                                     |

##### Example Value

<details>
 <summary>Click to expand</summary>

> ```json
> {
>  "id": 0,
>  "date": "2024-09-17T11:15:16.995Z",
>  "against": "string",
>  "field": 0
> }
> ```

</details>

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

### Get Single and Group Data

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetSingle/nao/{id}</b></code> <code>(Get Single Nao)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Nao to retrieve                                         |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetSingle/issue/{id}</b></code> <code>(Get Single Issue)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Issue to retrieve                                       |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetSingle/note/{id}</b></code> <code>(Get Single Note)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Note to retrieve                                        |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetSingle/clinicVisit/{id}</b></code> <code>(Get Single Clinic Visit)</code></summary>

##### Parameters

> | name          |  type     | data type               | description                                                           |
> |---------------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id            |  required | int                     | The ID of the Clinic Visit to retrieve                                |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetSingle/game/{id}</b></code> <code>(Get Single Game)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Game to retrieve                                        |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetGroup/issue/{nao}</b></code> <code>(Get Issues by Nao)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | nao       |  required | int                     | The Nao ID to retrieve issues for                                     |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetGroup/note/{nao}</b></code> <code>(Get Notes by Nao)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | nao       |  required | int                     | The Nao ID to retrieve notes for                                      |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetGroup/clinicVisit/{nao}</b></code> <code>(Get Clinic Visits by Nao)</code></summary>

##### Parameters

> | name          |  type     | data type               | description                                                           |
> |---------------|-----------|-------------------------|-----------------------------------------------------------------------|
> | nao           |  required | int                     | The Nao ID to retrieve clinic visits for                              |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetAll/naos</b></code> <code>(Get All Naos)</code></summary>

##### Parameters

> None

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetAll/issues</b></code> <code>(Get All Issues)</code></summary>

##### Parameters

> None

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetAll/notes</b></code> <code>(Get All Notes)</code></summary>

##### Parameters

> None

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetAll/clinicVisits</b></code> <code>(Get All Clinic Visits)</code></summary>

##### Parameters

> None

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>GET</code> <code><b>/api/RobotManager/GetAll/games</b></code> <code>(Get All Games)</code></summary>

##### Parameters

> None

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"value":[...],"formatters":[],"contentTypes":[],"declaredType":null,"statusCode":200}`                                      |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

### Delete Data
<details>
 <summary><code>DELETE</code> <code><b>/api/RobotManager/Delete/nao/{id}</b></code> <code>(Delete Nao)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Nao to delete                                           |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>DELETE</code> <code><b>/api/RobotManager/Delete/issue/{id}</b></code> <code>(Delete Issue)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Issue to delete                                         |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>DELETE</code> <code><b>/api/RobotManager/Delete/note/{id}</b></code> <code>(Delete Note)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Note to delete                                          |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>DELETE</code> <code><b>/api/RobotManager/Delete/clinicVisit/{id}</b></code> <code>(Delete Clinic Visit)</code></summary>

##### Parameters

> | name          |  type     | data type               | description                                                           |
> |---------------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id            |  required | int                     | The ID of the Clinic Visit to delete                                  |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>

<details>
 <summary><code>DELETE</code> <code><b>/api/RobotManager/Delete/game/{id}</b></code> <code>(Delete Game)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Game to delete                                          |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |

</details>
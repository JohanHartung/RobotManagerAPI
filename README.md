# Robot Manager API

## API Calls

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
>  "id": 0,
>  "name": "string",
>  "headID": "string",
>  "bodyID": "string",
>  "warrantyExtension": 0,
>  "purchased": "2024-09-17T11:48:29.256Z",
>  "issues": [
>    0
>  ],
>  "notes": [
>    0
>  ],
>  "clinicVisits": [
>    0
>  ],
>  "status": 0
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
>  "notes": "string",
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

### Advanced Updates

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/SetStatus/{nao, status}</b></code> <code>(Set Status)</code></summary>
 
##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | nao       |  required | int                     | The ID of the Nao to set status for                                   |
> | status    |  required | Status                  | The new status for the Nao                                            |

##### Responses
> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |
</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/ReplicateIssue/{id, dateTime}</b></code> <code>(Replicate Issue)</code></summary>

##### Parameters
> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id        |  required | int                     | The ID of the Issue to replicate                                      |
> | dateTime  |  required | DateTime                | The date and time of replication                                      |
##### Responses
> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |
</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/SolveIssue/{issue, dateTime, report}</b></code> <code>(Solve Issue)</code></summary>

##### Parameters
> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | issue     |  required | int                     | The ID of the Issue to solve                                          |
> | dateTime  |  required | DateTime                | The date and time of solving                                          |
> | report    |  required | string                  | The report of the solution                                            |
##### Responses
> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |
</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/EndClinicVisit/{clinicVisit, dateTime, report}</b></code> <code>(End Clinic Visit)</code></summary>

##### Parameters
> | name          |  type     | data type               | description                                                           |
> |---------------|-----------|-------------------------|-----------------------------------------------------------------------|
> | clinicVisit   |  required | int                     | The ID of the Clinic Visit to end                                     |
> | dateTime      |  required | DateTime                | The date and time of ending                                           |
> | report        |  required | string                  | The report of the clinic visit                                        |
##### Responses
> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |
</details>

<details>
 <summary><code>POST</code> <code><b>/api/RobotManager/AddIssueToClinicVisit/{clinicVisit, issue}</b></code> <code>(Add Issue to Clinic Visit)</code></summary>
 
##### Parameters
> | name          |  type     | data type               | description                                                           |
> |---------------|-----------|-------------------------|-----------------------------------------------------------------------|
> | clinicVisit   |  required | int                     | The ID of the Clinic Visit to add the issue to                        |
> | issue         |  required | int                     | The ID of the Issue to add                                            |
##### Responses
> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `application/json`                | `{"status":"OK"}`                                                   |
> | `404`         | `application/json`                | `{"status":"Not Found"}`                                            |
</details>


### Get Data
#### Get Single Data

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

#### Get Group Data

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

#### Get All Data

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

## Schemas
<details>
 <summary>Nao</summary>

> ```json
>{
>   "id": "integer($int32)",
>   "name": {
>     "type": "string",
>     "nullable": true
>   },
>   "headID": {
>     "type": "string",
>     "nullable": true
>   },
>   "bodyID": {
>     "type": "string",
>     "nullable": true
>   },
>   "warrantyExtension": "integer($int32)",
>   "purchased": "string($date-time)",
>   "issues": {
>     "type": "array",
>     "items": "integer($int32)",
>     "nullable": true
>   },
>   "notes": {
>     "type": "array",
>     "items": "integer($int32)",
>     "nullable": true
>   },
>   "clinicVisits": {
>     "type": "array",
>     "items": "integer($int32)",
>     "nullable": true
>   },
>   "status": {
>     "type": "Statusinteger($int32)",
>     "Enum": [0, 1, 2]
>   } 
>}
> ```
</details>

<details>
 <summary>Game</summary>

> ```json
>{
>   "id": "integer($int32)",
>   "date": "string($date-time)",
>   "against": "string",
>   "nullable": true,
>   "field": "Fieldinteger($int32)",
>   "Enum": [0, 1, 2, 3]
>}
> ```
</details>

<details>
 <summary>Note</summary>

> ```json
>{
>   "id": "integer($int32)",
>   "nao": "integer($int32)",
>   "title": {
>     "type": "string",
>     "nullable": true
>   },
>   "description": {
>     "type": "string",
>     "nullable": true
>   },
>   "date": "string($date-time)"   
>}
> ```
</details>

<details>
 <summary>Issue</summary>

> ```json
>{
>   "id": "integer($int32)",
>   "nao": "integer($int32)",
>   "title": "string",
>   "nullable": true,
>   "description": "string",
>   "nullable": true,
>   "replicated": "boolean",
>   "solved": "boolean",
>   "date": "string($date-time)",
>   "replicatedDate": "string($date-time)",
>   "solvedDate": "string($date-time)",
>   "solvedReport": {
>     "type": "string",
>     "nullable": true   
>   }
>}
> ```
</details>

<details>
 <summary>ClinicVisit</summary>

> ```json
>{
>  "id": "integer($int32)",
>  "nao": "integer($int32)",
>  "date": "string($date-time)",
>  "issues": {
>    "type": "array",
>    "items": "integer($int32)",
>    "nullable": true
>  },
>  "isBack": "boolean",
>  "backReport": {
>    "type": "string",
>    "nullable": true
>  }
>}
> ```

</details>

<details>
 <summary>Status</summary>

> ```json
>{
>   "Enum": [0, 1, 2],
>   "EnumDescriptions": {
>     "0": "Free",
>     "1": "Game",
>     "2": "Clinic"
>}
> ```
</details>

# ER-диаграмма. Вариант 10

Проектируемая схема БД. В ЛР1 подключение БД не выполняется.

```mermaid
erDiagram
    MASTER ||--o{ REPAIR : performs
    WAREHOUSE ||--o{ DEVICE_PLACEMENT : stores
    REPAIR ||--o| DEVICE_PLACEMENT : occupies
    COMPONENT_RECEIPT ||--|{ RECEIPT_COMPONENT : contains
    COMPONENT ||--o{ RECEIPT_COMPONENT : received
    REPAIR ||--o{ REPAIR_COMPONENT : consumes
    COMPONENT ||--o{ REPAIR_COMPONENT : used
    MASTER {
        int Id PK
        string FullName
        int Qualification
    }
    COMPONENT {
        int Id PK
        string Name
        string Description
    }
    WAREHOUSE {
        int Id PK
        string Name
        int Capacity
    }
    COMPONENT_RECEIPT {
        int Id PK
        datetime ReceiptDate
    }
    REPAIR {
        int Id PK
        int MasterId FK
        string DeviceName
        int RepairType
        decimal Revenue
        datetime RepairDate
    }
    RECEIPT_COMPONENT {
        int ReceiptId PK,FK
        int ComponentId PK,FK
        int Quantity
    }
    REPAIR_COMPONENT {
        int RepairId PK,FK
        int ComponentId PK,FK
        int Quantity
    }
    DEVICE_PLACEMENT {
        int Id PK
        int RepairId FK
        int WarehouseId FK
        int PlaceNumber
        datetime PlacementDate
    }
```

Класс ComponentQuantity представляет строку комплектующих внутри ComponentReceipt или Repair.
Идентификатор владельца задается содержащей коллекцией; при подключении БД это две таблицы-связки.
RepairId в DEVICE_PLACEMENT уникален; пара WarehouseId, PlaceNumber также уникальна.
Номер места от 1 до Capacity. Остаток: приход минус расход. Выручка — сумма Revenue
по дате ремонта и мастеру. RepairType — битовая маска нескольких видов работ;
при отчете по отдельным видам сумма за ремонт не должна дублироваться без правила распределения.

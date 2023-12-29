# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "00000000-0000-0000-0000-0000000000000000",
    "hostId": "00000000-0000-0000-0000-0000000000000000",
    "name": "yummy menu",
    "averageRating": 4.5, 
    "description": " a menu with yummy food",
    "section":[
        {
            "id": "00000000-0000-0000-0000-0000000000000000",
            "name": "Appetizers",
            "description": "Starters",
            "items":[
                {
                    "id": "00000000-0000-0000-0000-0000000000000000",
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles",
                    "price": 5.99
                }
            ]
        }
    ],
    "createdDateTime": "2020-01-01%00:00:00.0000000Z",
    "updateDateTime": "2020-01-01%00:00:00.0000000Z",
    "dinnerId":[
        "00000000-0000-0000-0000-0000000000000000",
        "00000000-0000-0000-0000-0000000000000000"
    ],
    "menuReviewIds":[
        "00000000-0000-0000-0000-0000000000000000",
        "00000000-0000-0000-0000-0000000000000000"
    ]
}
```
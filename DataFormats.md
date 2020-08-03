# Data Formats

#### Used for reference during project

### Database Tables

auction:
    auction_id
    org_name
    start_time
    end_time

item:
    item_id
    auction_id
    title
    subtitle (description of item)
    pic (url)
    starting_bid

category:
    category_id
    name

item_category:
    item_id
    category_id

### JSON 

```json
    item {
        itemID: Number,
        title: String,
        subtitle: String,
        pic: String,
        category: String,
        startingBid: Decimal
    }

    auction {
        startTime: datetime,
        endTime: datetime
    }
```


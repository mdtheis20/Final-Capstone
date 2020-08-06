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

bid:
    bid_id
    items_id
    amount
    time_placed
    user_id


### JSON 

```json
    {
    "item_ID": 2,
    "auction_ID": 1,
    "title": "Josh's Waterbottle",
    "subtitle": null,
    "pic": "https://images.unsplash.com/photo-1523362628745-0c100150b504?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1493&q=80",
    "starting_Bid": 150.0,
    "categories": [
      
    ],
    "bids": [
      {
        "item_ID": 2,
        "bid_ID": 9,
        "user_Name": "user",
        "amount": 10.0
      },
      {
        "item_ID": 2,
        "bid_ID": 10,
        "user_Name": "admin",
        "amount": 11.0
      },
      {
        "item_ID": 2,
        "bid_ID": 11,
        "user_Name": "user",
        "amount": 15.0
      }
    ]
  }

    auction {
        startTime: datetime,
        endTime: datetime
    }

    bid {
      bid_ID:
      item_ID:
      user_ID:
      time_placed:
      amount:
    }
```

# Endpoints

GET localhost:4320/auction --gets list of all items

GET localhost:4320/auction/categories  -- gets list of all categories

GET /auction/item/{item_id}

POST /auction/item/{item_id}  --post a bid


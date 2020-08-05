<template>
    <div>
        <h3>{{item.title}}</h3>
        <img :src="item.pic" :alt="item.subtitle">
        <p>{{item.subtitle}}</p>
        <ul>
            <li v-for="bid in item.listOfBids" :key="bid.bidID">
                {{bid.amount}} |&nbsp;
                {{bid.userID}}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
     props: {
        item: {
                itemID: Number,
                title: '',
                subtitle: '',
                pic: '',
                startingBid: Number,
                category: [],
                listOfBids:[ {
                    bidID: 0,
                    itemID: 2,
                    userID: 2,
                    amount: 500,
                    time: null
                },
                {

                }
                ]
            }
    }
}
</script>

<style>

</style>
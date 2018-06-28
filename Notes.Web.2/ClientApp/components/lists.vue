<template>
    <div>
        <h1>Lists</h1>

        <p>This component demonstrates fetching data from the server.</p>

        <p v-if="!lists">
            <em>Loading...</em>
        </p>


        <div id="myLists" class="is-flex" v-if="lists">

            <article class="card is-responsive" v-for="list in lists" :key="list.$id" v-cloak="">
                <header class="card-header">
                    <p class="card-header-title">
                        <p class="has-text-grey-darker has-text-left has-text-justified">
                            {{list.name}}
                        </p>
                    </p>
                    <div class="card-header-icon">
                        <p>

                        </p>
                    </div>
                </header>

                <div class="card-image is-unselectable" v-on:dblclick="open(list)">
                    <figure class="is-card-image filter">
                        <img width="200" v-bind:src="`C:\\work\\github\\Notes\\Notes.Web.2\\data\\photos\\unnamed.jpg`">
                    </figure>
                </div>

                <div class="card-content">
                    <div class="media-right">

                        <ul>
                            <li v-for="item in list.listItems">
                                <input type="checkbox" v-model="item.checked">
                                    {{ item.name }}</input>
                            </li>
                        </ul>
                        
                        <!--<div v-for="item in list.listItems" :key="item.$id">
                            {{ item.name }}
                        </div>-->
                        
                    </div>

                </div>
        </article>
    </div>


    </div>
</template>

<script>
    export default {
    data() {
    return {
    lists: null
    }
    },

    methods: {
    },

    async created() {
    // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
    // TypeScript can also transpile async/await down to ES5
    try {
    console.log('logging');

    let response = await this.$http.get('/api/Lists')
    console.log(response.data);
    this.lists = response.data;
    } catch (error) {
    console.log(error)
    }
    // Old promise-based approach
    //this.$http
    //    .get('/api/SampleData/WeatherForecasts')
    //    .then(response => {
    //        console.log(response.data)
    //        this.forecasts = response.data
    //    })
    //    .catch((error) => console.log(error))*/
    }
    }
</script>

<style>
</style>

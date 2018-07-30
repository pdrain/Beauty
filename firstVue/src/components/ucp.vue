<template>
    <div>
        微信认证中转页
    </div>
</template>

<script>
import querystring from 'querystring'
    export default{
        data(){
            return {}
        },
        created(){
            let params = this.$route.query.target
            console.log(params)
        }
    }
</script>
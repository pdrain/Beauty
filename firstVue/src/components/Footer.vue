<template>
    <div class="bottom-menu">
        <a @click="goHome">发现美丽</a>
        <a @click="goShop">积分商城</a>
        <a @click="goMy">我</a>
    </div>
</template>


<script>
export default {
    methods:{
        goHome(){
            this.$router.push('/')
        },
        goShop(){
            this.$router.push('/shop')
        },
        goMy(){
            this.$router.push('/user')
        }
    }
}
</script>

<style>

</style>


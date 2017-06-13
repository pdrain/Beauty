<template>
    <div>
        {{msg}}<br/>
        <router-link :to="{ path: '/projects'}">返回首页</router-link>
    </div>
</template>

<script>
export default {
    data() {
         let _msg = this.$route.params['msg'];
        return {

            msg: _msg
        }



    }

}

</script>
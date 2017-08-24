<template>
  <div>
    <UserHeader  title="我的积分"></UserHeader>

      </div>
</template>
<script  type="application/ecmascript">

import UserHeader from './UserHeader'


export default {
    components:{UserHeader},
    data(){
        return {
          msg:'Welcome to User Center!'

        }

    },
    mounted(){
        
        
    },
    methods:{


    }

}

</script>


<style scoped lang="less">
@import '../assets/index.less';
.my-points h1 {
    margin: 0px;
    padding: 0px;
    line-height: 30px;
    height: 30px;
    text-align: left;
    font-size: 14px;
    font-weight: normal;
}

.my-points h1 span {
    border-left: 3px @font-hot-color solid;
    padding-left: 8px;
}
</style>

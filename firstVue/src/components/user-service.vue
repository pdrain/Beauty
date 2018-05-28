<template>
  <div>
      <u-header title="客服中心"></u-header>
      <div class='user-service'></div>
      <c-footer></c-footer>
  </div>
</template>

<script>
    
import Header from './UserHeader'
import Footer from './Footer'
export default{
    components:{'u-header':Header,'c-footer':Footer}
}

</script>

<style scoped lang='less'>
.user-service{
    background: #fff;
    min-height:350px;
}
</style>


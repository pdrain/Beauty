<template>
  <div  v-title='"用户保障"'>
      <u-header></u-header>
       <div class='user-rights'></div>
      <c-footer></c-footer>
  </div>
</template>

<script>
    
import Header from './UserHeader'
export default{
    components:{'u-header':Header}
}

</script>


<style scoped lang='less'>
.user-rights{
    background: #fff;
    min-height:350px;
}
</style>
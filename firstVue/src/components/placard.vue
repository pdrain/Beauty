<template>
    <div>
        <UserHeader  backurl="/user"  title="我的分享海报"></UserHeader>
         <div  class="placard">
            <div class="item" @click="goToPlaCard">11</div>
            <div class="item">11</div>
            <div class="item">11</div>
         </div>
          <div  class="placard">
            <div class="item">11</div>
            <div class="item">11</div>
            <div class="item">11</div>
         </div>
    </div>
</template>

<script>
import UserHeader from "./UserHeader";
export default {
  components: { UserHeader },
  methods:{
      goToPlaCard(){
          this.$router.push('/')
      }
  }
};
</script>

<style>
.placard {
  display: flex;
}
.placard .item {
  width: 5rem;
  height: 5rem;
  line-height: 5rem;
  background: #fff;
}
</style>


<template>
  <section class="loading" :class="{'show':loadingState}" >
    <div class="dialog">{{message}}</div>
    <div class="mask"></div>
  
  </section>
</template>
<style scoped lang="less">
@import '../assets/index.less';

.loading{width: 100%; height: 100%; position: absolute;top:0px; left: 0px; display :none;  }
.loading .mask{height: 100%; background:@mask-bg; opacity: @mask-opcity; }
.loading .dialog{width: 70%; min-height: @dialog-msg-min-height; line-height: @dialog-msg-line-height; color: @dialog-msg-font-color; z-index: 9999;margin-left: 15%; margin-top: 50%; position: absolute;background: @dialog-msg-bg; border-radius: 5px; }
.loading.show{display: block;}
</style>

<script>
import { mapGetters } from 'vuex'

export default {
  computed: mapGetters({
      loadingState: 'loadingState',
      message:'displayMessage'
  })
}

</script>

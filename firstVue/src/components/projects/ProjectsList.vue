<template>
  <div class="projects">
    <div class="item" v-for="item in list">
      <router-link :to="{ path: '/projects-detail', query: { id: item.ID }}">
        <img src="../../assets/none.jpg" />
        <div class="title">{{item.Title}}</div>
        <div class="price">0</div>
      </router-link>
    </div>
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';

.projects{width: 100%;height: auto;}
.projects .item{float: left; width: 50%; min-height: @listitem-min-height; border:@listitem-border-width @listitem-border-color solid; background: @listitem-bgcolor}
.projects .item img{width: 90%; height: auto; margin: auto;padding-top: 8px;}
.projects .item .title,.projects .item .price{width:90%; margin: auto; min-height: @listitem-row-min-height; line-height: @listitem-line-height;}
.projects .item a{text-decoration: none; color:@listitem-font-color;}

</style>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'projects-list',
  data() {
    return {}
  },
  computed: mapGetters({
    list: 'ProjectList'
  })
}
</script>
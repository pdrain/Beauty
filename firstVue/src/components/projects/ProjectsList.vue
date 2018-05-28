<template>
  <div class="projects">
    <div class="item" v-for="item in list" :key="item.ID">
      <router-link :to="{ path: '/projects-detail', query: { id: item.ID }}">
      <div class="left">
        <img src="../../assets/none.jpg" />
      </div>
      <div class="right">
        <div class="title">{{item.Name}}</div>
        <div class="shortdesc">{{item.ShorDesc}}</div>
        <div class="price">0<span>已约 200 人</span></div>
      </div>
      <div class="clr"></div>
      </router-link>
    </div>
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';

.projects{width: 100%;height: auto;}
.projects .item{float: left; width: 100%; min-height: @listitem-min-height;  border:@listitem-border-width @listitem-border-color solid; background: @listitem-bgcolor}
.projects .item img{width: 90%; height: auto; margin: auto;}
.projects .item .title,.projects .item .price,.projects .item .shortdesc{width:90%; margin: auto; min-height: @listitem-row-min-height; line-height: @listitem-line-height;}
.projects .item .price,.projects .item .shortdesc{font-size: 12px;}
.projects .item .shortdesc{color:#ccc;}
.projects .item .price{color:@listitem-font-hotcolor;}
.projects .item .price span{float:right;}
.projects .item a{text-decoration: none; color:@listitem-font-color;}

.projects .item .left{width: 35%; float: left; padding-top: 8px;}
.projects .item .right{width: 65%; float: right;text-align: left; padding-top: 8px;}
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
  }),
  created(){
    this.$store.dispatch("");
  }
}
</script>
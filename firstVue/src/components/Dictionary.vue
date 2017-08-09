<template>
  <div v-title="'美容字典'" class='hmn-dict' style="{'height':screenHeight}">
    <span class="navi">
      <dl>
        <dd v-for="(item,i) in dict" :key="item.ID" :class="{'active':showActiveNavi(i,item.ID)}" @click="switchNavi(item.ID)" v-cloak>{{item.Name}}</dd>
      </dl>
    </span>
    <span class="detail">
      <div class="childs" v-for="child in childs" :key="child.ID">
        <div class="sub-title">{{child.Name}}&nbsp;></div>
        <dl>
          <dd v-for="item in child.Childs" :key="item.ID" @click="viewDetail(item.ID,item.Name)">{{item.Name}}</dd>
        </dl>
        <div class="split-line"></div>
      </div>
    </span>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      activeNavi: ''
    }
  },
  computed: {
    ...mapGetters({
      dict: 'parentDict',
      childs: 'childDictionary'
    })
  },
  beforeCreate() {
    let _this = this;
    _this.$store.dispatch('getParentDict').then(function () {
      _this.$store.dispatch('getChildDict')
    })

  },
  methods: {
    switchNavi(id) {
      this.activeNavi = id
      this.$store.dispatch('getChildDict', id)
    },
    showActiveNavi(index, id) {
      return this.activeNavi === id || (!this.activeNavi && index == 0)
    },
    viewDetail(id, name) {
      let url = '/dict/article'
      url += '?id=' + encodeURIComponent(id) + '&name=' + encodeURIComponent(name)
      this.$router.push(url)
    }
  }
}
</script>



<style scoped lang="less">
@import '../assets/index.less';

.hmn-dict {
  line-height: 40px;
  height: 100%;
}

.navi {
  flex: 0;
  float: left;
  width: 25%;

  height: 100%;
  background: #f0f0f0;
  box-sizing: border-box;
}

.navi .active {
  border-left: 1px @dict-navi-hotcolor solid;
  border-right: 0px;
  background: #fff;
}

.detail {
  flex: 0;
  float: left;
  width: 75%;
  height: 100%;
  background: #fff;
  text-align: left;
  padding: 0px 5px;
  box-sizing: border-box;
}

.detail .split-line {
  height: 10px;
  border-bottom: 1px #f0f0f0 solid;
}

.detail dd {
  display: inline-block;
  min-width: 60px;
  padding: 0px 10px;
  text-align: center;
  background: #faf4fa;
  height: 30px;
  border-radius: 17px;
  line-height: 30px;
  font-size: 12px;
}
</style>

<template>
  <div class="pagenav">
    <ul>
      <li>
        <router-link :to="{ path: '/subscribers' }">客户预约</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/achievement' }">业绩</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/sales' }">业务员管理</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/sales-apply' }">业务员申请</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/project-cat' }">美容项目分类</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/project-list' }">美容项目列表</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/product-cat' }">美容产品分类</router-link>
      </li>
      <li>
        <router-link :to="{ path: '/product-list' }">美容产品列表</router-link>
      </li>
    </ul>
  </div>
</template>



<script>
export default {

}
</script>

<style>
.pagenav {
  height: 100%;
  width: 100%;
  border-right: 1px #ccc solid;
  background: #fff;
}

.pagenav ul{margin: 0px; padding:0px;}

.pagenav ul li{line-height: 30px;text-indent: 10px; border-bottom: 1px dashed #ccc;}
.pagenav ul li:hover{background: #f0f0f0;}
.pagenav ul li a{display: block; width: 100%; height:100%;}
</style>

<template>
<div v-title="'产品'">
  <VHeader></VHeader>
  <VList></VList>
</div>

</template>

<script>
import VHeader from './shop/ShopHeader'
import VList from './SHOP/ProductList'
export default {
  name: 'shop',
  components:{VHeader,VList}
}
</script>

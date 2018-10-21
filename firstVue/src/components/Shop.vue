<template>
<div v-title="'积分商城'">
  <top-banner :code='1001'></top-banner>
  <productlist></productlist>
  
  <c-footer></c-footer>
</div>

</template>

<script>
import productlist from "./shop/ProductList";
import topBanner from "./common/advertisment";
import Footer from "./Footer";

export default {
  components: { productlist, topBanner, "c-footer": Footer },
  data() {
    return {};
  }
};
</script>

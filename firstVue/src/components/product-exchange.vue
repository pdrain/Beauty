<template>
    <div v-title='"礼品兑换"'>
        <div class="product-info">
            <ul>
                <li>
                    <img src=""/>
                </li>
                <li>产品名称：</li>
                <li></li>
                <li>产品描述：</li>
                <li></li>
                <li>兑换数量：</li>
                <li></li>
            </ul>
        </div>
        <div class="exchange-info">
            <ul>
                <li>
                    <label>联系人：</label>
                    <input type="text">
                </li>
                <li>
                    <label>联系电话：</label>
                    <input type="text">
                </li>
                <li>
                    <label>收货地址：</label>
                    <input type="text">
                </li>
            </ul>
            <button disabled="disabled">确认换购</button>
        </div>
          <c-footer></c-footer>
    </div>
</template>

<script>
import Footer from "./Footer";
    export default {
        name: 'product-exchange',
          components: {  "c-footer": Footer },
        data(){
            return {
                prdid:'prdid'
            }
        },
        mounted(){},
        methods:{}
    }
</script>

<template>
    <div class="order-list">
        <dl>
            <dd v-for="item in data" :key="item.name">
                <div class="left">
                    <span>{{item.date}}</span><br/>
                    <span>{{item.name}}</span>
                </div>
                <div class="right">
                     <span>¥ 12800</span><br/>
                    <span>已完成</span>
                </div>
            </dd>
        </dl>
    </div>
</template>

<script>
export default {
    props: {
        data:null
    }
}
</script>

<style scoped lang="less">
@import '../../assets/index.less';
.order-list {
    width: 100%;
    background: #fff;
}

.order-list dl,
.order-list dd {
    margin: 0px;
    padding: 0px;
}

.order-list dd {
    list-style: none;
    border-bottom: 1px #f0f0f0 solid;
    height: 60px;
    padding-top: 5px;
    padding-bottom: 5px;
    box-sizing: border-box;
}

.order-list dd .left,
.order-list dd .right {
    display: block;
    float: left;
    height: 100%;
    line-height: 25px;
}

.order-list dd .left {
    width: 80%;
    text-align: left;
    padding-left: 8px;
}

.order-list dd .right {
    width: 20%;
    color: @font-hot-color ;
    text-align: right;
    padding-right: 8px;
}
</style>


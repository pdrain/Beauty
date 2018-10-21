import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {}
const getters = {}
const actions = {
    getAdvertismentList({ },_code){
        return new Promise(function (resolve) {
            let param = {code:_code};
            axios.post(api.ADVERTISMENT,param).then(response => {
                if(response.status==200){
                    let data = response.data;
                    if(data.code=='000000'){
                        resolve(data.result)
                       }else{
                        alert('获取轮播图片数据失败！');
                       }
                }else{
                    alert('网络链接失败！');
                }
               
               
            });
        });
    }
}
const mutations = {}

export default {
    state,
    getters,
    actions,
    mutations
}
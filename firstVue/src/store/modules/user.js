import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'
import WX from '../../config/WeXin'

const state = {
    wxInfo: {},
    //userInfo:{}
    // orders: {},
    // comments: {},
    // agrees: {},
    // notice: {},
    // subscribes: {},
    // points: {},


}

const getters = {
    WXInfo: state => state.wxInfo,
    //UserInfo: state => state.userInfo,
    // Orders: state => state.orders,
    // Comments: state => state.comments,
    // Agrees: state => state.agrees,
    // Notice: state => state.notice,
    // Subscribes: state => state.subscribes,
    // Points: state => state.points

}

const actions = {
    getLostorageUserInfo({ commit, state }){
        return new Promise(function (resolve, reject) {
            let _userInfo; 
            if(location.href.indexOf('www.meilituibian.cn')>=0){
                _userInfo =  JSON.parse(localStorage.getItem('userinfo'));
               
            }else{
                _userInfo={"password":null,"userId":1,"openId":"oeJvEwrIkEnDzIzp5huT4nEmt0HY","userName":null,"nickName":"背着PC去流浪","shopName":null,"contact":null,"taxpayerCode":null,"city":null,"province":null,"headUrl":null,"remark":null,"createTime":"2018-07-14","userType":0,"userTypeName":"普通用户","contractNo":null,"parent":"","phone":null,"address":null,"numberId":null,"status":0,"statusName":null,"businessLicense":null,"point":0,"jobTitle":0,"jotTitleName":"队员","updateTime":null,"WX":{"access_token":"11_rUthCp1nFBhz3DV2TxyWjRYmfQDZEmdZM80wONHeOwFKAsfvqLC_8xp6siTIxESn3I6dH6hRF9hogL_nh6iasw","country":"中国","province":"广东","city":"深圳","openid":"oeJvEwrIkEnDzIzp5huT4nEmt0HY","sex":1,"nickname":"背着PC去流浪","headimgurl":"http://thirdwx.qlogo.cn/mmopen/vi_32/KMhESiaQOl479MKjB61JHxFKq1320ZumLRIf1uXoYo1zs8pCYN5sg34yCAkciaquSzwnR0SicicoHFWiaHXyCI2y8GA/132","language":"zh_CN","privilege":[]}}
            }
            resolve(_userInfo)
        })
       
    },
    getMyClient ({ commit, state }, openId) {
        return new Promise(function (resolve, reject) {
            let url = api.USER_CLIENTS + openId
            axios.get(url).then(response => {
                if (response.data.code == 0) {
                    let data = response.data.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject();
                    }
                }
            })
        })
    },
    savePartnerInfo({commit, state},data){
        return new Promise(function(resolve,reject){
            let url = api.REGISTER 
            axios.post(url,data).then(response => {
                
                if (response.data.code == 0) {
                    let data = response.data.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject(response.data.message);
                    }
                }
            })
        })
    },
    getUpgradeInfo({commit, state},openId){
        return new Promise(function(resolve,reject){
            let url = api.USER_GET_UPGRADEINFO.replace('{openId}',openId)
            axios.get(url,{}).then(response => {
                
                if (response.data.code == 0) {
                    let data = response.data.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject(response.data.message);
                    }
                }
            })
        })
    },
    doUpgrade({commit, state},openId){
        return new Promise(function(resolve,reject){
            let url = api.USER_DO_UPGRADE.replace('{openId}',openId)
            axios.post(url,{}).then(response => {
                
                if (response.data.code == 0) {
                    let data = response.data.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject(response.data.message);
                    }
                }
            })
        })
    },
    getBaseInfo({commit, state},infoId){
        return new Promise(function(resolve,reject){
            let url = api.GET_BASE_INFO.replace('{infoId}',infoId)
            axios.get(url,{}).then(response => {
                
                if (response.data.code == 0) {
                    let data = response.data.data;
                    resolve(data)
                } else {
                    if (reject && typeof (reject) == 'function') {
                        reject(response.data.message);
                    }
                }
            })
        })
    }
}

const mutations = {
   
}

export default {
    state,
    getters,
    actions,
    mutations
}
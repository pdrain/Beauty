import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {
    hospitals: [],         //医院列表
    hospitalDetail:null      //医院详情
}

const getters = {
    HospitalList: state => state.hospitals,
    HospitalDetail: state => state.hospitalDetail
}


const actions = {
    quereHospitals({ commit, state }) {
        commit(types.QUEREY_HOSPITAL_LIST);
    },
    queryHospitalDetail({ commit, state }, hospitalId) {
        commit(types.QUEREY_HOSPITAL_DETAIL, hospitalId);
    }
}

const mutations = {
    
    [types.QUEREY_HOSPITAL_LIST](state, hospitalId) {
        
        let _url_hospital_list = util.format(api.HOSPITAL_LIST, hospitalId);
        axios.get(_url_hospital_list).then(response => {

            if (response.data.Code == 0) {
                let result = response.data.Result;
                state.list = result;
            }
            else {
                alert(response.data.Message);
            }
        })
    },
    [types.QUEREY_HOSPITAL_DETAIL](state, hospitalId) {
        //获取项目明细        
        let _url_hospital_detail = util.format(api.HOSPITAL_DETAIL, hospitalId);

        axios.get(_url_hospital_detail).then(response => {
            if (response.data.Code == 0) {
                state.hospitalDetail = response.data.Result;
            }
            else {
                alert(response.data.Message);
            }
        })
    }
}



export default {
    state,
    getters,
    actions,
    mutations
}
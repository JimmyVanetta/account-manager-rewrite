/* eslint-disable import/prefer-default-export */
import Vue from 'vue';
import Vuex from 'vuex';
import accounts from './modules/AccountStore';
import employees from './modules/EmployeeStore';

Vue.use(Vuex);

export const store = new Vuex.Store({
  modules: {
    accounts,
    employees,
  },
});

Vue.use(Vuex);

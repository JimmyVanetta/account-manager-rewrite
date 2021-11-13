/* eslint-disable linebreak-style */
import Vue from 'vue';
import Vuex from 'vuex';
import accounts from './modules/AccountsStore';
import employees from './modules/EmployeesStore';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    accounts,
    employees,
  },
});

Vue.use(Vuex);

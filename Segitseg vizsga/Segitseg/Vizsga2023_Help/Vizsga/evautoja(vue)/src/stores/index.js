import { defineStore } from "pinia";

export const useAutoVoteStore = defineStore({
    id: 'autoVoteStore',
    state: ()=>({ 
        kivAuto: -1
     }),
    getters:{
        getAuto(state){
            
            return state.kivalasztottAuto;
        },
    },
    actions:{
        autoKivalasztas(kivalasztottAuto){
            this.kivAuto = kivalasztottAuto
        }
    }
});
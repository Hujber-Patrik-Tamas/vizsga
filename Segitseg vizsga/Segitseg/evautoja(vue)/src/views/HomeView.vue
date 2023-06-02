<script setup>
import dataservice from '../services/dataservice.js'
import { ref } from 'vue'
import { useAutoVoteStore } from '../stores'

const gyartok = ref([])
const gyartoAutoi = ref([])
const kivalasztottGyarto = ref()
let aktAuto = useAutoVoteStore()

dataservice.getGyartok()
    .then((resp) => {
        gyartok.value = resp.data;
        //console.log(gyartok.value);
    })
    .catch((err) => {
        console.log(err);
    });

const valaszto = () => {    
dataservice.getGyartoAutoi(kivalasztottGyarto.value)
    .then((resp) => {
        gyartoAutoi.value = resp.data;
        console.log(gyartoAutoi.value);
    })
    .catch((err) => {
        console.log(err);
    });
}

const asd = (a) => {
    aktAuto.autoKivalasztas(a)
}

</script>

<template>
    <div class="container">
        <h1 class="text-center">Car of the year 2023</h1>

        <div class="col-8 offset-2 col-md-6 offset-md-3 col-lg-4 offset-lg-4 my-4">
            <label class="form-label">Manufacturer:</label>
            <select class="form-select" v-model="kivalasztottGyarto" @change="valaszto">
                <option v-for="gyarto in gyartok" :value="gyarto.id">{{ gyarto.name }}</option>
            </select>
        </div>

        <div class="row">
            <div v-for="auto in gyartoAutoi" class="col-12 col-md-6 col-xl-4">
                <div class="card w-100">
                    <img :src="auto.pictureUrl" class="card-img-top p-3">
                    <div class="card-body">
                        <h5 class="card-title">{{ auto.model }}</h5>
                        <p class="card-text">
                            {{ auto.description }}
                        </p>
                        <p  class="text-center mb-0" @click="asd(auto)">
                        <!-- <button @click="asd(auto)" class="btn btn-primary">
                        Vote
                        </button> -->
                            <router-link to="/voting"  class="btn btn-primary">Vote</router-link>
                        </p>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

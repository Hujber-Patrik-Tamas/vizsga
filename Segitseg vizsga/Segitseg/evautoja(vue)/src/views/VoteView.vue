<script setup>
import dataservice from '../services/dataservice.js'
import { ref } from 'vue'
import { useAutoVoteStore } from '../stores'

const autok = ref([])
const vote = ref({})
let error = ref()
const accepted = ref(false)
const aktAuto = useAutoVoteStore()


dataservice.getAutok()
    .then((resp) => {
        autok.value = resp.data;
        //console.log(autok.value);
    })
    .catch((err) => {
        console.log(err);
    });

const sendVote = (selectedAuto) => {
    if (accepted.value) {
        vote.value.carId = selectedAuto
        console.log(`Az érték: ${vote.value}`);
        dataservice.postVote(vote.value)
            .then((resp) => {
                alert("OK")
            })
            .catch((err) => {
                error.value = err.response.data.message
                console.log(err);
            });
    }
    else {
        error.value = "Please accept the term of use!"
    }
}

const hibakezelo = () => {
    error.value = null
}

</script>
<template>
    <div class="container">
        <h1 class="text-center">Voting</h1>

        <div class="form col-10 offset-1 col-md-8 offset-md-2 col-lg-6 offset-lg-3 my-4">

            <div class="mb-3">
                <label for="car" class="form-label">Selected car:</label>
                <select id="car" class="form-select" v-model="aktAuto.kivAuto.id">
                    <option v-for="auto in autok" :value="auto.id">{{ auto.model }}</option>
                </select>
            </div>

            <div class="mb-3">
                <label for="email" class="form-label">Your e-mail address:</label>
                <input v-model="vote.email" type="text" class="form-control" id="email">
            </div>

            <div class="mb-3">
                <label for="comment" class="form-label">Comment:</label>
                <textarea v-model="vote.comment" id="comment" class="form-control" rows="3"></textarea>
            </div>

            <div class="mb-3">
                <input v-model="accepted" type="checkbox" id="acceptedConditions" class="form-check-input">
                <label for="acceptedConditions" class="form-check-label">Accept terms of use</label>
            </div>

            <p>{{ aktAuto.kivAuto.id }}</p>
            
            <div class="mb-3 text-center">
                <input type="button" value="Vote" class="btn btn-primary" @click="sendVote(aktAuto.kivAuto.id)">
            </div>

            <div v-if="error" class="alert alert-danger alert-dismissible fade show" role="alert">
                {{ error }}
                <button type="button" class="btn-close" @click="hibakezelo" aria-label="Close"></button>
            </div>
        </div>

        <div class="modal fade" id="successfullVoteModal" tabindex="-1">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header mx-auto">
                        <h5 class="modal-title text-center">Your vote has been successfully registered</h5>
                    </div>
                    <div class="modal-footer mx-auto">
                        <a class="btn btn-secondary" href="car-list.html">Back to list</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>
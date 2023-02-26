<template>
  <h1 align="left">Update your hotel</h1>
  <div id="app1">
    <div class="form-group col">
      <label>Hotel id</label>
      <input name="id" type="text" class="form-control" v-model="formData.id" />
    </div>
    <div class="form-group col">
      <button class="btn btn-secondary form-group col" v-on:click="fillPage">
        Sync
      </button>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Hotel Name</label>
        <input
          name="hotelName"
          type="text"
          class="form-control"
          v-model="formData.hotelName"
        />
      </div>
      <div class="form-group col">
        <label>Location</label>
        <input
          name="location"
          type="text"
          class="form-control"
          v-model="formData.location"
        />
      </div>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Room Types</label>
        <input
          name="roomTypes"
          type="text"
          class="form-control"
          v-model="formData.roomTypes"
        />
      </div>
      <div class="form-group col">
        <label>Complimentary Food</label>
        <input
          name="complimentaryFood"
          type="checkbox"
          class="form-control"
          v-model="formData.complimentaryFood"
        />
      </div>
    </div>
    <div class="form-group col">
      <label>Prices</label>
      <input
        name="prices"
        type="text"
        class="form-control"
        v-model="formData.prices"
      />
    </div>
  </div>
  <div class="form-group">
    <button class="btn btn-primary" v-on:click="updateBook">
      Update hotel
    </button>
  </div>
  <br />
  <h5 v-if="res.resp != false">Updated hotel successfully!</h5>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      res: {
        resp: false,
      },
      formData: {
        id: null,
        name: null,
        hotelName: null,
        location: null,
        roomTypes: null,
        complimentaryFood: false,
        prices: null,
      },
    };
  },
  methods: {
    async updateBook() {
      let res = await axios.put(
        "https://localhost:7225/api/Admin/" + this.formData.id,
        this.formData,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      console.log(res);
      if (res.status == 204) {
        this.res.resp = true;
      }
    },

    async fillPage() {
      let result = await axios.get(
        "https://localhost:7225/api/Admin/" + this.formData.id
      );

      console.log(result);
      this.formData = result.data;
    },
  },
};
</script>

<style></style>

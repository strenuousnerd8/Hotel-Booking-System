<template>
  <h1 align="left">Add hotel</h1>
  <div id="app1">
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
    <br />
    <div class="form-group">
      <button class="btn btn-primary" v-on:click="hotel">Add hotel</button>
    </div>
    <br />
    <h5 v-if="res.resp != false">Added hotel successfully!</h5>
  </div>
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
    async hotel() {
      let res = await axios({
        method: "post",
        url: "https://localhost:7225/api/Admin",
        data: this.formData,
        headers: {
          "Content-Type": "application/json",
        },
      });
      console.log(res);
      if (res.status == 201) {
        this.res.resp = true;
      }
    },
  },
};
</script>

<style></style>

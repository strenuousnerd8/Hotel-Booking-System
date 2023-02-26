<template>
  <h1 align="left">Book</h1>
  <div id="app1">
    <div class="form-row">
      <div class="form-group col">
        <label>Hotel id</label>
        <input
          name="hotelId"
          type="text"
          class="form-control"
          v-model="formData.hotelId"
        />
      </div>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Name</label>
        <input
          name="name"
          type="text"
          class="form-control"
          v-model="formData.name"
        />
      </div>
      <div class="form-group col">
        <label>Phone No</label>
        <input
          name="phoneNo"
          type="number"
          class="form-control"
          v-model="formData.phoneNo"
        />
      </div>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Age</label>
        <input
          name="age"
          type="number"
          class="form-control"
          v-model="formData.age"
        />
      </div>
      <div class="form-group col">
        <label>Email</label>
        <input
          name="email"
          type="text"
          class="form-control"
          v-model="formData.email"
        />
      </div>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Aadhar / PAN No</label>
        <input
          name="aadharPAN"
          type="number"
          class="form-control"
          v-model="formData.aadharPAN"
        />
      </div>
      <div class="form-group col">
        <label>Room type</label>
        <input
          name="roomType"
          type="text"
          class="form-control"
          v-model="formData.roomType"
        />
      </div>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Members</label>
        <input
          name="members"
          type="number"
          class="form-control"
          v-model="formData.members"
        />
      </div>
      <div class="form-group col">
        <label>Check-in</label>
        <input
          name="checkin"
          type="text"
          class="form-control"
          v-model="formData.checkin"
        />
      </div>
    </div>
    <div class="form-row">
      <div class="form-group col">
        <label>Check-out</label>
        <input
          name="checkout"
          type="text"
          class="form-control"
          v-model="formData.checkout"
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
    <div class="form-group">
      <button class="btn btn-primary" v-on:click="book">Make Booking</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      formData: {
        hotelId: null,
        name: null,
        phoneNo: null,
        age: null,
        email: null,
        aadharPAN: null,
        roomType: null,
        members: null,
        checkin: null,
        checkout: null,
        complimentaryFood: null,
      },
    };
  },
  methods: {
    async book() {
      axios({
        method: "post",
        url: "https://localhost:7239/api/Customer",
        data: this.formData,
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => console.log(response))
        .catch((error) => console.log(error));
    },
  },
};
</script>

<style></style>

<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <div id="topOfPage">
        <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
        <router-link :to="{ name: 'login' }">Have an account?</router-link>
      </div>

      <div
        class="alert alert-danger"
        role="alert"
        v-if="registrationErrors"
      >{{ registrationErrorMsg }}</div>

      <div id="enterName">
        <label for="first name">First Name:</label>
        <input type="text" required placeholder="First Name" v-model="name.firstName" />

        <label for="last name">Last Name:</label>
        <input type="text" required placeholder="Last Name" v-model="name.lastName" />
      </div>

      <div id="streetAddress">
        <label for="address">Address:</label>
        <input type="text" required placeholder="Address" v-model="address.streetAddress" />
      </div>

      <div id="cityStateZip">
        <label for="city">City:</label>
        <input type="text" required placeholder="City" v-model="address.city" />

        <label for="state">State:</label>
        <select required v-model="address.state">
          <option value="AL">Alabama</option>
          <option value="AK">Alaska</option>
          <option value="AZ">Arizona</option>
          <option value="AR">Arkansas</option>
          <option value="CA">California</option>
          <option value="CO">Colorado</option>
          <option value="CT">Connecticut</option>
          <option value="DE">Delaware</option>
          <option value="DC">District Of Columbia</option>
          <option value="FL">Florida</option>
          <option value="GA">Georgia</option>
          <option value="HI">Hawaii</option>
          <option value="ID">Idaho</option>
          <option value="IL">Illinois</option>
          <option value="IN">Indiana</option>
          <option value="IA">Iowa</option>
          <option value="KS">Kansas</option>
          <option value="KY">Kentucky</option>
          <option value="LA">Louisiana</option>
          <option value="ME">Maine</option>
          <option value="MD">Maryland</option>
          <option value="MA">Massachusetts</option>
          <option value="MI">Michigan</option>
          <option value="MN">Minnesota</option>
          <option value="MS">Mississippi</option>
          <option value="MO">Missouri</option>
          <option value="MT">Montana</option>
          <option value="NE">Nebraska</option>
          <option value="NV">Nevada</option>
          <option value="NH">New Hampshire</option>
          <option value="NJ">New Jersey</option>
          <option value="NM">New Mexico</option>
          <option value="NY">New York</option>
          <option value="NC">North Carolina</option>
          <option value="ND">North Dakota</option>
          <option value="OH">Ohio</option>
          <option value="OK">Oklahoma</option>
          <option value="OR">Oregon</option>
          <option value="PA">Pennsylvania</option>
          <option value="RI">Rhode Island</option>
          <option value="SC">South Carolina</option>
          <option value="SD">South Dakota</option>
          <option value="TN">Tennessee</option>
          <option value="TX">Texas</option>
          <option value="UT">Utah</option>
          <option value="VT">Vermont</option>
          <option value="VA">Virginia</option>
          <option value="WA">Washington</option>
          <option value="WV">West Virginia</option>
          <option value="WI">Wisconsin</option>
          <option value="WY">Wyoming</option>
        </select>

        <label for="zip code">Zip Code:</label>
        <input type="text" required placeholder="Zip" pattern="[0-9]*" v-model="address.zip" />
      </div>

      <div id="phoneContact">
        <label for="phone number">Phone Number (xxx-xxx-xxxx):</label>
        <input
          type="tel"
          required
          placeholder="xxx-xxx-xxxx"
          pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
          v-model="user.phone_number"
        />

        <label for="available times">Best time to contact you:</label>
        <select name="times" id="times" required v-model="user.contact_times">
          <option value="morning">Morning</option>
          <option value="afternoon">Afternoon</option>
          <option value="evening">Evening</option>
        </select>
      </div>

      <label for="username" class="sr-only">Email address:</label>
      <input
        type="email"
        id="username"
        class="form-control"
        placeholder="email"
        v-model="user.username"
        required
        autofocus
      />

      <div id="passwords">
        <label for="password" class="sr-only">Password</label>
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
          pattern ="(?=.*?[!?@#$%^*])(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).{8,}"
          title="Must contain at least one number, one symbol, one uppercase letter, one lowercase letter, and at least 8 or more characters"
        />
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required
        />
      </div>

      <!-- <input type="checkbox" required>
      <label for="Verify you have read the privacy policy">I confirm that I have read and agree to the <a class="trigger_popup_fricc">Privacy Policy</a></label>
      <div class="hover_background_fricc">
        <span class="helper"></span>
        <div>
          <div class="popupCloseButton">&times;</div>
          <p>I consent to donate all purchased items directly back to team Wildcard</p>
        </div>
      </div> -->
      <button class="btn btn-lg btn-primary btn-block" type="submit">Create Account</button>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
        name: "",
        address: "",
        phone_number: "",
        contact_times: "",
      },

      name: {
        firstName: "",
        lastName: ""
      },

      address: {
        streetAddress: "",
          city: "",
          state: "",
          zip: "",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        this.user.name = this.name.firstName + " " + this.name.lastName
        this.user.address = this.address.streetAddress + " " + this.address.city + " " + this.address.state + " " + this.address.zip
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },


    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};

</script>

<style>
#topOfPage {
  display: flexbox;
}
</style>

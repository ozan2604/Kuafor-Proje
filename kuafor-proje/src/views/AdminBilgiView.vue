<template>
 <div>
  <div class="container">
      <div class="form-section">
        <h2>Hizmet Bilgileri Güncelleme</h2>
        <form @submit.prevent="submitForm" class="form">
          <div class="form-group">
            <label for="updateId">Hizmet ID:</label>
            <input type="text" id="updateId" v-model="updateFormData.id" required>
          </div>
          <div class="form-group">
            <label for="updateHizmetAdı">Hizmet Adı:</label>
            <input type="text" id="updateHizmetAdı" v-model="updateFormData.hizmetAdı" required>
          </div>
          <div class="form-group">
            <label for="updateDetay">Detay Bilgisi:</label>
            <textarea id="updateDetay" v-model="updateFormData.detay" required></textarea>
          </div>
          <div class="form-group">
            <label for="updateFiyat">Fiyat:</label>
            <input type="number" id="updateFiyat" v-model.number="updateFormData.fiyat" required>
          </div>
          <button type="submit">Güncelle</button>
        </form>
      </div>
      
      <div class="form-section">
        <h2>Yeni Hizmet Ekle</h2>
        <form @submit.prevent="submitForm2" class="form">
          <div class="form-group">
            <label for="addHizmetAdı">Hizmet Adı:</label>
            <input type="text" id="addHizmetAdı" v-model="addFormData.hizmetAdı" required>
          </div>
          <div class="form-group">
            <label for="addDetay">Detay Bilgisi:</label>
            <textarea id="addDetay" v-model="addFormData.detay" required></textarea>
          </div>
          <div class="form-group">
            <label for="addFiyat">Fiyat:</label>
            <input type="number" id="addFiyat" v-model.number="addFormData.fiyat" required>
          </div>
          <button type="submit">Ekle</button>
        </form>
      </div>
      
      <div class="form-section">
        <h2>Hizmet Sil</h2>
        <form @submit.prevent="submitForm3" class="form">
          <div class="form-group">
            <label for="deleteId">Hizmet ID:</label>
            <input type="text" id="deleteId" v-model="id" required>
          </div>
          <button type="submit">Sil</button>
        </form>
      </div>
    </div>

    <div class="container">
      <div class="form-section">
        <h2>Kuaför Bilgileri Güncelleme</h2>
        <form @submit.prevent="submitForm4" class="form">
          <div class="form-group">
            <label for="updateId">Kuaför ID:</label>
            <input type="text" id="updateId" v-model="updateFormKuafor.id" required>
          </div>
          <div class="form-group">
            <label for="updateKuaförAdı">Kuaför Adı:</label>
            <input type="text" id="updateKuaförAdı" v-model="updateFormKuafor.kuaförName" required>
          </div>
          <div class="form-group">
            <label for="updateTel">Kuaför Numarası:</label>
            <textarea id="updateTel" v-model="updateFormKuafor.kuaförTel" required></textarea>
          </div>
          <button type="submit">Güncelle</button>
        </form>
      </div>
      
      <div class="form-section">
        <h2>Yeni Kuaför Ekle</h2>
        <form @submit.prevent="submitForm5" class="form">
          <div class="form-group">
            <label for="addKuaförName">Kuaför Adı:</label>
            <input type="text" id="addKuaförName" v-model="addFormKuafor.kuaförName" required>
          </div>
          <div class="form-group">
            <label for="addTel">Kuaför Numarası:</label>
            <textarea id="addTel" v-model="addFormKuafor.kuaförTel" required></textarea>
          </div>
          <button type="submit">Ekle</button>
        </form>
      </div>
      
      <div class="form-section">
        <h2>Kuaför Sil</h2>
        <form @submit.prevent="submitForm6" class="form">
          <div class="form-group">
            <label for="deleteKuaförId">Kuaför ID:</label>
            <input type="text" id="deleteKuaförId" v-model="id" required>
          </div>
          <button type="submit">Sil</button>
        </form>
      </div>
    </div>
    <div class="container">
      
      <div class="form-section">
        <h2>Yorum Sil</h2>
        <form @submit.prevent="submitForm7" class="form">
          <div class="form-group">
            <label for="deleteYorumId">Yorum ID:</label>
            <input type="text" id="deleteYorumId" v-model="id" required>
          </div>
          <button type="submit">Sil</button>
        </form>
      </div>

      <div class="form-section">
        <h2>Rezervasyon Sil</h2>
        <form @submit.prevent="submitForm8" class="form">
          <div class="form-group">
            <label for="deleteRezervasyonId">Rezervasyon ID:</label>
            <input type="text" id="deleteRezervasyonId" v-model="id" required>
          </div>
          <button type="submit">Sil</button>
        </form>
      </div>

      
     
    </div>
 </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        updateFormData: {
          id: '',
          hizmetAdı: '',
          detay: '',
          fiyat: 0
        },
        addFormData: {
          hizmetAdı: '',
          detay: '',
          fiyat: 0
        },
        id: '',
        updateFormKuafor:{
            kuaförName: '',
            kuaförTel: ''
        },

        addFormKuafor:{
            kuaförName: '',
            kuaförTel: ''
        }
      };
    },
    methods: {
      submitForm() {
        axios.put(`https://localhost:7134/api/Hizmet/Update`, this.updateFormData)
          .then(response => {
            console.log('Güncelleme başarılı:', response.data);
            alert('Hizmet bilgileri başarıyla güncellendi!');
            this.resetForm();
          })
          .catch(error => {
            console.error('Güncelleme hatası:', error);
            alert('Hizmet bilgileri güncellenirken bir hata oluştu.');
          });
      },
      resetForm() {
        this.updateFormData.id = '';
        this.updateFormData.hizmetAdı = '';
        this.updateFormData.detay = '';
        this.updateFormData.fiyat = 0;
      },
      submitForm2() {
        axios.post(`https://localhost:7134/api/Hizmet/Save`, this.addFormData)
          .then(response => {
            console.log('Ekleme başarılı:', response.data);
            alert('Yeni hizmet başarıyla eklendi!');
            this.resetForm2();
          })
          .catch(error => {
            console.error('Ekleme hatası:', error);
            alert('Yeni hizmet eklenirken bir hata oluştu.');
          });
      },
      resetForm2() {
        this.addFormData.hizmetAdı = '';
        this.addFormData.detay = '';
        this.addFormData.fiyat = 0;
      },
      submitForm3() {
        axios.delete(`https://localhost:7134/api/Hizmet/Remove/${this.id}`)
          .then(response => {
            console.log('Silme başarılı:', response.data);
            alert('Hizmet başarıyla silindi!');
            this.resetForm3();
          })
          .catch(error => {
            console.error('Silme hatası:', error);
            alert('Hizmet silinirken bir hata oluştu.');
          });
      },
      resetForm3() {
        this.id = '';
      },

      submitForm4() {
        axios.put(`https://localhost:7134/api/Kuaför/Update`, this.updateFormKuafor)
          .then(response => {
            console.log('Güncelleme başarılı:', response.data);
            alert('kuaför bilgileri başarıyla güncellendi!');
            this.resetForm4();
          })
          .catch(error => {
            console.error('Güncelleme hatası:', error);
            alert('Kuaför bilgileri güncellenirken bir hata oluştu.');
          });
      },
      resetForm4() {
        this.updateFormKuafor.kuaförName = '',
        this.updateFormKuafor.id = '';
        this.updateFormKuafor.kuaförTel = '';
        
        
      },

      submitForm5() {
        axios.post(`https://localhost:7134/api/Kuaför/Save`, this.addFormKuafor)
          .then(response => {
            console.log('Ekleme başarılı:', response.data);
            alert('Yeni kuaför başarıyla eklendi!');
            this.resetForm5();
          })
          .catch(error => {
            console.error('Ekleme hatası:', error);
            alert('Yeni kuaför eklenirken bir hata oluştu.');
          });
      },
      resetForm5() {
        this.updateFormKuafor.kuaförName = '',
        this.updateFormKuafor.kuaförTel = '';
      },

      submitForm6() {
        axios.delete(`https://localhost:7134/api/Kuaför/Remove/${this.id}`)
          .then(response => {
            console.log('Silme başarılı:', response.data);
            alert('Kuaför başarıyla silindi!');
            this.resetForm6();
          })
          .catch(error => {
            console.error('Silme hatası:', error);
            alert('Kuaför silinirken bir hata oluştu.');
          });
      },
      resetForm6() {
        this.id = '';
      },

      submitForm7() {
        axios.delete(`https://localhost:7134/api/Yorum/Remove/${this.id}`)
          .then(response => {
            console.log('Silme başarılı:', response.data.data);
            alert('Yorum başarıyla silindi!');
            this.resetForm7();
          })
          .catch(error => {
            console.error('Silme hatası:', error);
            alert('Yorum silinirken bir hata oluştu.');
          });
      },
      resetForm7() {
        this.id = '';
      },

      submitForm8() {
        axios.delete(`https://localhost:7134/api/Rezervasyon/Remove/${this.id}`)
          .then(response => {
            console.log('Silme başarılı:', response.data);
            alert('Rezervasyon başarıyla silindi!');
            this.resetForm8();
          })
          .catch(error => {
            console.error('Silme hatası:', error);
            alert('Rezervasyon silinirken bir hata oluştu.');
          });
      },
      resetForm8() {
        this.id = '';
      },
    }
  };
  </script>
  
  <style scoped>
  .container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: 20px;
    padding: 20px;
  }
  
  .form-section {
    border: 1px solid #ccc;
    border-radius: 5px;
    padding: 15px;
  }
  
  .form {
    display: grid;
    gap: 10px;
  }
  
  .form-group {
    margin-bottom: 10px;
  }
  
  label {
    display: block;
    margin-bottom: 5px;
  }
  
  input[type="text"],
  input[type="number"],
  textarea {
    width: calc(100% - 12px);
    padding: 6px;
    font-size: 14px;
    border: 1px solid #ccc;
    border-radius: 3px;
  }
  
  textarea {
    height: 80px;
  }
  
  button {
    padding: 8px 16px;
    font-size: 14px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 3px;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #0056b3;
  }
  </style>
  
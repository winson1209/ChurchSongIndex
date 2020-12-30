<template>
	<form class="filter-form">
		<div class="grid-container">
			<div>
				<p>
					<label for="searchCode">Code: </label>
					<input id="searchCode" v-model="searchCode" />
				</p>
				<p>
					<label for="stroke">筆劃：</label>
					<select id="stroke" v-model.number="stroke">
						<option></option>
						<option v-for="n in 26"	:key="n" :value="n">
							{{n}}
						</option>
					</select>
				</p>
				<p>
					<label for="nameLength">歌名字數：</label>
					<select id="nameLength" v-model.number="nameLength">
						<option></option>
						<option v-for="n in 18"	:key="n" :value="n">
							{{n}}
						</option>
					</select>
				</p>
				<p>
					<label for="wordContains">包含關鍵詞：</label>
					<input id="wordContains" v-model="wordContains" />
				</p>
			</div>
			<p>
				<label for="key">調：</label>
				<select id="key" v-model="key">
					<option></option>
					<option value="C">C</option>
					<option value="Cm">Cm</option>
					<option value="D">D</option>
					<option value="Dm">Dm</option>
					<option value="E">E</option>
					<option value="Eb">Eb</option>
					<option value="Em">Em</option>
					<option value="F">F</option>
					<option value="G">G</option>
					<option value="Gm">Gm</option>
					<option value="A">A</option>
					<option value="Ab">Ab</option>
					<option value="Am">Am</option>
					<option value="Bb">Bb</option>
					<option value="Bbm">Bbm</option>
					<option value="Bm">Bm</option>
				</select>
			</p>
		</div>
		<div class="grid-container">
			<button type="button" class="button" @click="onSubmit">搜尋</button>
			<button type="button" class="button" @click="onShowAll">顯示全部</button>
		</div>
	</form>
</template>

<script>
export default {
  name: 'filter-form',
	data() {
		return {
			stroke: null,
			nameLength: null,
			searchCode: null,
			wordContains: null,
			key: null,
		}
	},
	methods: {
		onSubmit() {
			let searchTerms = {
				stroke: this.stroke,
				nameLength: this.nameLength,
				searchCode: this.searchCode,
				wordContains: this.wordContains,
				key: this.key,
			}
			
			this.$emit('search-terms-entered', searchTerms)
		},
		onShowAll() {
			let searchTerms = {
				stroke: null,
				nameLength: null,
				searchCode: null,
				wordContains: null,
				key: null,
			}
			
			this.stroke = null
			this.nameLength = null
			this.searchCode = null
			this.wordContains = null
			this.key = null
			
			this.$emit('search-terms-entered', searchTerms)
		},
	}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.button {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 15px 15px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 0px 20px;
  cursor: pointer;
}

.button:hover {
	background-color: #e8f25e; /* Yellow */
	color: #000000; /* Black */
}

label {
	font-size: 20px;
}

input, select {
	height: 30px
}

</style>
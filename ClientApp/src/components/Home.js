import React, { Component } from 'react';
import { get } from 'axios';
import $ from 'jquery';

window.jQuery = $;
window.$ = $;
global.jQuery = $;

export class Home extends Component {
  static displayName = Home.name;

  constructor() {
      super();
      this.state = {
          firstNum : 0,
          secondNum : 0,
          action : "add",
          result : 0,
          history: []
      };
      this.calc = this.calc.bind(this);
      this.remove = this.remove.bind(this);
      this.update = this.update.bind(this);

      
      
  }
  
  componentWillMount() {

      get("/api/getHistory").then((result) => {
          this.setState({history: JSON.stringify(result.data)})
      });
      
  }

    calc(){
      
        const firstNum = $('#FirstNum').val();
        const secondNum = $('#SecondNum').val();
        const action = $('#Action').val();
        
        this.setState({firstNum: firstNum});
        this.setState({secondNum: secondNum});
        this.setState({action: action});
        

      
      get("/api/calc?firstNum=" + firstNum + "&secondNum=" + secondNum + "&what=" + action).then((result) => {
          this.setState({result: result.data.result});
          this.setState({history: JSON.stringify(result.data.history)})
      });
  }
  
  remove(index){
      get("/api/remove?index=" + index).then((result) => {
          this.setState({history: JSON.stringify(result.data)})
      });
  }
  
  update(index){
      var history = JSON.parse(this.state.history);
      var calc = history[index];
      $("#FirstNum").val(calc.firstNum);
      $("#SecondNum").val(calc.secondNum);
      $("#Action").val(calc.action);
      $("#Result").val(calc.result);
  }
  
  render () {


      
    return (
      <div>
          <br/>
          <br/>
        <div>
          <input type="number" id="FirstNum" value={this.state.firstNum} onChange={() => this.calc()}  />
          &nbsp;&nbsp;
          <select id="Action" onChange={() => this.calc()}>
              <option value="add">+</option>
              <option value="sub">-</option>
              <option value="mul">X</option>
              <option value="div">:</option>
          </select>
          &nbsp;&nbsp;
          <input type="number" id="SecondNum" value={this.state.secondNum} onChange={() => this.calc()} />
          &nbsp;&nbsp;
          =
          &nbsp;&nbsp;
          <input type="number" id="Result" value={this.state.result} />
           
      </div>
        <div>
            <b>Calculation History:</b>
            <br/>
            <ul>
            {
                
                this.state.history.length > 0 ? JSON.parse(this.state.history).map((element,index) => {
                    switch(element.action){
                        case "add":
                            return <li key={index}>{element.firstNum} + {element.secondNum} = {element.result} <button onClick={() => this.remove(index)}>-</button> <button onClick={() => this.update(index)}>U</button></li>
                            break;
                        case "sub":
                            return <li key={index}>{element.firstNum} - {element.secondNum} = {element.result} <button onClick={() => this.remove(index)}>-</button> <button onClick={() => this.update(index)}>U</button></li>
                            break;
                        case "mul":
                            return <li key={index}>{element.firstNum} * {element.secondNum} = {element.result} <button onClick={() => this.remove(index)}>-</button> <button onClick={() => this.update(index)}>U</button></li>
                            break;
                        case "div":
                            return <li key={index}>{element.firstNum} / {element.secondNum} = {element.result} <button onClick={() => this.remove(index)}>-</button> <button onClick={() => this.update(index)}>U</button></li>
                            break;
                    }
                     
            }) : ""
            }
            </ul>
        </div>
      </div>
    );
  }
}
        

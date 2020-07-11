import { Component, OnInit } from '@angular/core';
import { Swal } from '../../lib/sweetalert2/sweetalert2';

@Component({
  selector: 'app-auth-gate',
  templateUrl: './auth-gate.component.html',
  styleUrls: ['./auth-gate.component.css']
})

export class AuthGateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  signUpRequiredPopUp = () => {
    Swal.fire({
        title: 'Hey, ' + localStorage.getItem('playerName') + '!\nTap Sign Up to play...',
        icon: 'info',
        html: 'By clicking sign up you agree to our terms and conditions policies.',
        showCloseButton: true,
        focusConfirm: true,
        confirmButtonText: '<span id="Register">Sign Up with messenger</span>'
    });
  }
}

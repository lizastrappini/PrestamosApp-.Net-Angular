import { CanActivateFn } from '@angular/router';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';


export const authGuard: CanActivateFn = (route, state) => {
  const token = localStorage.getItem('token');
  if (token) {
    return true;
  } else {
    return false;
  }
}

export const authUser: CanActivateFn = (route, state) => {
  const token = localStorage.getItem('dniUser');
  if (token) {
    return false;
  } else {
    return true;
  }
}

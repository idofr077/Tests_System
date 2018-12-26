﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee
    {
        int _id;
        string _last_name;
        string _first_name;
        DateTime _date_of_birth;
        gender _Gender;
        int _phone;
        Address _address;
        vehicle _learn_vehicle;
        kind_of_gearbox _gearbox;
        string _school;
        string _teacher_name;
        int _numOfLessons;

        public Trainee(int id, string last_name, string first_name, DateTime date_of_birth, gender Gender, int phone, Address address, vehicle learn_vehicle, kind_of_gearbox gearbox, string school, string teacher_name, int numOfLessons)
        {
            this.id = id;
            this.last_name = last_name;
            this.first_name = first_name;
            this.date_of_birth = date_of_birth;
            this.Gender = Gender;
            this.phone = phone;
            this.address = address;
            this.learn_vehicle = learn_vehicle;
            this.gearbox = gearbox;
            this.school = school;
            this.teacher_name = teacher_name;
            this.numOfLessons = numOfLessons;
        }
        public Trainee(Trainee Temp)
        {
            _id = Temp.id;
            _last_name = Temp.last_name;
            _first_name = Temp.first_name;
            _date_of_birth = Temp.date_of_birth;
            _Gender = Temp.Gender;
            _phone = Temp.phone;
            _address = Temp.address;
             _gearbox = Temp.gearbox;
            _school = Temp.school;
            _teacher_name = Temp.teacher_name;
            _numOfLessons = Temp.numOfLessons;
        }
        //פרופרטים
        public int id
        {
            get { return _id; }
            set
            { 
                _id = value;
            }
        }
        public string last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public string first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
        public DateTime date_of_birth
        {
            get { return _date_of_birth; }
            set { _date_of_birth = value; }
        }
        public gender Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public int phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public Address address
        {
            get { return _address; }
            set { _address = value; }
        }
        public vehicle learn_vehicle
        {
            set { _learn_vehicle = value; }
            get { return _learn_vehicle; }
        }
        public kind_of_gearbox gearbox
        {
            set
            {
                _gearbox = value
;
            }
            get { return _gearbox; }
        }
        public string school
        {
            set
            {
                _school = value
;
            }
            get { return _school; }
        }
        public string teacher_name
        {
            set { _teacher_name = value; }
            get { return _teacher_name; }
        }
        public int numOfLessons
        {
            set { _numOfLessons = value; }
            get { return _numOfLessons; }
        }
        // ToString
        public override string ToString()
        {
            return first_name + " " + last_name + "/n" + id + "/n" + date_of_birth + "/n" + Gender + "/n" + phone + "/n" + address + "/n" + school + "/n" + teacher_name + "/n";
        }
    }
}
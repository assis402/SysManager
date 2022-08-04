import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";


@Component({
             selector: 'app-custom-modal',
             templateUrl: './custom-modal.component.html',
             styleUrls: ['./custom-modal.component.scss']
})
export class CustomModalComponent implements OnInit {
    ngOnInit(): void{
    }

constructor(){}

@Input() title: string = '';
@Input() body: string = '';
@Input() showModal: boolean =false;

@Output() closeModal = new EventEmitter();
@Output() cancelModal = new EventEmitter();
@Output() confirmModal = new EventEmitter();

modalConfirm(){
    this.confirmModal.emit('confirm');
}

modalClose(){
   this.closeModal.emit('close');
}

modalCancel(){
    this.cancelModal.emit('cancel');
}

}

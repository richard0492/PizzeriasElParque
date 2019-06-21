<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="PizzeríaElParque.AgregarAdmin" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">

                    <form role="form">
                        <div class="form-group">
                            <label>Text Input</label>
                            <input class="form-control" />
                            <p class="help-block">Help text here.</p>
                        </div>
                        <div class="form-group">
                            <label>Text Input with Placeholder</label>
                            <input class="form-control" placeholder="PLease Enter Keyword" />
                        </div>
                        <div class="form-group">
                            <label>Just A Label Control</label>
                            <p class="form-control-static">info@yourdomain.com</p>
                        </div>
                        <div class="form-group">
                            <label>File input</label>
                            <input type="file" />
                        </div>
                        <div class="form-group">
                            <label>Text area</label>
                            <textarea class="form-control" rows="3"></textarea>
                        </div>
                        <div class="form-group">
                            <label>Checkboxes</label>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" value="" />Checkbox Example One
                                </label>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" value="" />Checkbox Example Two
                                </label>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" value="" />Checkbox Example Three
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Inline Checkboxes Examples</label>
                            <label class="checkbox-inline">
                                <input type="checkbox" />
                                One
                            </label>
                            <label class="checkbox-inline">
                                <input type="checkbox" />
                                Two
                            </label>
                            <label class="checkbox-inline">
                                <input type="checkbox" />
                                Three
                            </label>
                        </div>
                        <div class="form-group">
                            <label>Radio Button Examples</label>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked />Radio Example One
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2" />Radio Example Two
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios3" value="option3" />Radio Example Three
                                </label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Select Example</label>
                            <select class="form-control">
                                <option>One Vale</option>
                                <option>Two Vale</option>
                                <option>Three Vale</option>
                                <option>Four Vale</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Multiple Select Example</label>
                            <select multiple class="form-control">
                                <option>One Vale</option>
                                <option>Two Vale</option>
                                <option>Three Vale</option>
                                <option>Four Vale</option>
                            </select>
                        </div>
                        <button type="submit" class="btn btn-default">Submit Button</button>
                        <button type="reset" class="btn btn-primary">Reset Button</button>

                    </form>
                    <br />





                </div>


            </div>


        </div>
    </div>

</asp:Content>
